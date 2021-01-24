        private static Dictionary<int, Animal> allAnimals = new Dictionary<int, Animal>();
        public void Get_table(OleDbConnection conn)
                {
                    String[] Animals = new string[] { "Cow", "Dog", "Goat", "Sheep" };
                    foreach(string animaltype in Animals)
                    {
                        using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM " + animal, conn))
                        {
                            using (OleDbDataReader reader = cmd.ExecuteReader())
                            {
                                if (!reader.HasRows)
                                {
                                    //MessageBox.Show("No tables found");
                                    continue;
                                }
                                while (reader.Read())
                                {
                                    int someAnimalId = 0;//<---- your animal id;
                                    var animal = reader.ToAnimal(animaltype);
                                    allAnimals.Add(someAnimalId, animal);
                                }
                            }
                        }
                    }
                }
