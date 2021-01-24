            public void dosomeWork()
            {
               for (int i = 0; i <= listline.Count; i += range)
                    {
                    MyVM.SafeOperationToGuiThread( () => { 
                        status.Text = "test if i can change label name without freezing";
                        isChecked(listline.GetRange(i, range));
                          }
    
                    }
    
                }
    
            }
