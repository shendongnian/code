    public delegate void WorkCompleted();
            /// <summary>
            /// Marks the end of the progress
            /// </summary>
            private void ProgressComplete()
            {
                if (!this.Dispatcher.CheckAccess())
                {
                    this.Dispatcher.BeginInvoke(new WorkCompleted(ProgressComplete), System.Windows.Threading.DispatcherPriority.Normal, null);
                }
                else
                {
                    this.buttonClose.Visibility = Visibility.Visible;
                    this.progressBarStatus.IsIndeterminate = false;
                }
            }
