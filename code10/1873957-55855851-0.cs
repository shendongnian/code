                string Name = "Apple,Samsung";
                string Quantity = "24,20";
                string[] names = Name.Split(',');
                string[] quantities = Quantity.Split(',');
                DataTable table = new DataTable();
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Quantity", typeof(string));
                for (int i = 0; i < names.Length; i++)
                    table.Rows.Add(new object[] { names[i], quantities[i] });
