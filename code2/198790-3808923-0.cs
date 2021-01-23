        public void Populate() {
            // for comparison, freezing the ui thread
            for (int i = 0; i < 1000000; i++) {
                listBox.Items.Add(i);
            }
        }
        private delegate void AddItemDelegate(int item);
        public void PopulateAsync() {
            // create a new thread which is iterating the elements
            new System.Threading.Thread(new System.Threading.ThreadStart(delegate() {
                // inside the new thread: iterate the elements
                for (int i = 0; i < 1000000; i++) {
                    // use the dispatcher to "queue" the insertion of elements into the UI-Thread
                    // DispatcherPriority.Background ensures Animations have a higher Priority and the UI does not freeze
                    // possible enhancement: group the "jobs" to small units to enhance the performance
                    listBox.Dispatcher.Invoke(new AddItemDelegate(delegate(int item) {
                        listBox.Items.Add(item);
                    }), System.Windows.Threading.DispatcherPriority.Background, i);
                }
            })).Start();
        }
