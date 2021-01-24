    public List<FinalDrink> GroupDrinks(List<Drink> drinkNames)
            {
    
                lstFinalDrink = new List<FinalDrink>();
                FinalDrink fDrink = new FinalDrink();
                var GetFirst = drinkNames.Where(x => x.Tag == 1).ToList();
                fDrink.name = GetFirst[0].name.ToString();
                lstFinalDrink.Add(fDrink);
                var Content = drinkNames.Where(x => x.Tag != 1).ToList();
                string itrVal = string.Empty;
                int prev = 0;
                string hcur = string.Empty;
                for (int i = 0; i < Content.Count(); i++)
                {
                    if (Content[i].Tag == 2)
                    {
                        hcur = GetFirst[0].name + " * " + Content[i].name;
                       
                        fDrink = new FinalDrink();
                        itrVal = GetFirst[0].name + " * " + Content[i].name;
                        fDrink.name = itrVal;
                        lstFinalDrink.Add(fDrink);
                        prev = Content[i].Tag;
                        itrVal = string.Empty;
    
                    }
    
                    else
                    {
                        fDrink = new FinalDrink();
                        itrVal = hcur + " * " + Content[i].name;
                        fDrink.name = itrVal;
                        lstFinalDrink.Add(fDrink);
                        prev = Content[i].Tag;
                        itrVal = string.Empty;
                    }
                }
    
                return lstFinalDrink;
            }
