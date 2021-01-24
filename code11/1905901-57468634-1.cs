            //Assuming these are the names that where added with their info
            listOfStudentsNames = new List<string>() { "Tom", "Andrea", "Zoey", "Mike", "Pete" };
            listOfStudentsHomeTown = new List<string>() { "home1", "home2", "home3", "home4", "home5" };
            listOfStudentsFavoriteFood = new List<string>() { "food1", "food2", "food3", "food4", "food5" };
            listOfStudentsFavoriteColor = new List<string>() { "color1", "color2", "color3", "color4", "color5" };
            Sort(listOfStudentsNames, 
                listOfStudentsHomeTown, 
                listOfStudentsFavoriteFood, 
                listOfStudentsFavoriteColor);
        }
        static List<string> listOfStudentsNames = new List<string>();
        static List<string> listOfStudentsHomeTown = new List<string>();
        static List<string> listOfStudentsFavoriteFood = new List<string>();
        static List<string> listOfStudentsFavoriteColor = new List<string>();
        public static void Sort(List<string> names, params List<string>[] otherInfo)
        {
            // I use params for the other info because you will be able 
            // to add more info-lists without making any changes to this code
            // save the index of each name
            var nameWithIndexes = names.Select(x => new Tuple<string, int>(x, names.IndexOf(x))).ToList();
            //sort the list by the names
            nameWithIndexes.Sort((x, y) => x.Item1.CompareTo(y.Item1));
            names.Clear();
            names.AddRange(nameWithIndexes.Select(x => x.Item1));
            // get de index of the names afert sorting
            var order = nameWithIndexes.Select(x => x.Item2);
            // sort the other info by the index order int the variable "order"
            for (int i = 0; i < otherInfo.Length; i++)
            {
                var newOrder = new List<string>();
                foreach (var index in order)
                {
                    newOrder.Add(otherInfo[i][index]);
                }
                otherInfo[i].Clear();
                otherInfo[i].AddRange(newOrder);
            }               
        }
