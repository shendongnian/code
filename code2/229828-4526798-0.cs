                textBox1.Text = "Enter Thread";
                Task t = Task.Factory.StartNew(delegate
                {
                    
                    for (int i = 0; i < 20; i++)
                    {
                        //My Long Running Work
                    }
                }). ContinueWith(ret => textBox1.Text = textBox1.Text + Environment.NewLine + "After Loop", TaskScheduler.FromCurrentSynchronizationContext());
