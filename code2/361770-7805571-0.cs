    string input = "tom: 1, john: 3, timmy: 5, cid: 8, ad: 88, hid: 99, mn: 33";
                string[] parts = input.Split(','); 
                StringBuilder result = new StringBuilder();
                int i = 1;
                while(i <= parts.Length) 
                {
                    result.Append(parts[i-1] + ","); 
                    if (i % 3 == 0)
                    {
                        result.Append("<br />");
                    }
                    i++;
                }
                MessageBox.Show(result.ToString());
