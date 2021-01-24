            private int brasProcessed = 0;
            private void TextBox_TextChanged(object sender, EventArgs e)
            {            
                int countOpenBra = textBox.Text.Count(c => c == '{');
                int countCloseBra = textBox.Text.Count(c => c == '}');
                //if there is a matched pair of {} (equal counts) and more { have appeared than we know we've processed before...
                if (countOpenBra == countCloseBra && countOpenBra > brasProcessed)
                {             
                    DraggableLabel ag = new DraggableLabel();
                    ag.Name = "A";
                    ag.Content = "you have bracket";    //(i + 1).ToString();
                    ag.BorderBrush = Brushes.Black;
                    ag.BorderThickness = new Thickness(2, 2, 2, 2);
                    DesigningCanvas.Children.Add(ag);    
                    ab = ag;  
                    //mark the current count of {} as processed so the code will not fire again until someone adds a new { } pair
                    brasProcessed = countOpenBra;  
                }           
            }
