public int CountS()
        {
            var numberS = 0;
            for (int i = 1; i <= 7; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    string box = "Box" + i.ToString() + "_" + j.ToString();
                    TextBox nameBox 
                        = UIHelper.FindChild<TextBox>(Application.Current.MainWindow, box); //using example linked above
                        //= textBoxes.First(tbx => tbx.Name == box); //if you got collection of your textboxes
                    numberS += nameBox.Text.Count(c => c == 'S'); //if you wont also count a small "s" add .ToUpper() before .Count
                }
            }
            return numberS;
        }
