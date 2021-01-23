    // Save
                SubmitOperation so = dataContext.SubmitChanges();
    
                // Callback
                so.Completed += (s, args) =>
                                    {
                                        // Error?
                                        if (so.HasError)
                                        {
                                            // Message
                                            MessageBox.Show(string.Format("The following error has occurred:\n\n{0}", so.Error.Message));
    
                                            // Set
                                            so.MarkErrorAsHandled();
                                        }
                                    };
