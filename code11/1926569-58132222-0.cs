                while (true)
                {
                    Application.DoEvents();
                    bool State = (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.A) == true);
                    // MessageBox.Show(State.ToString());
    
                    if (State)
                    {
                        MessageBox.Show("Entered !");
                        break;
                    }
                }
