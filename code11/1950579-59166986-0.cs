    private void Button_Click(object sender, RoutedEventArgs e)
            {
                var curSelection = cmbTest.Text;
                Console.WriteLine("We Hit Here1");
                if (curSelection.Equals("Item2"))
                {
                    Console.WriteLine("We Hit Here2");               
                }
            }
