        static void Main(string[] args)
        {
            AddStudent("Mike", "home1", "food1", "color1");
            AddStudent("Pete", "home2", "food2", "color2");
            AddStudent("Andrea", "home3", "food3", "color3");
            AddStudent("Zoey", "home4", "food4", "color4");
            AddStudent("Tom", "home5", "food5", "color5");
        }
        static List<string> listOfStudentsNames = new List<string>();
        static List<string> listOfStudentsHomeTown = new List<string>();
        static List<string> listOfStudentsFavoriteFood = new List<string>();
        static List<string> listOfStudentsFavoriteColor = new List<string>();
        public static void AddStudent(string name, string homeTown, string favFood, string favColor)
        {
            int namePos = BinaryInsert(listOfStudentsNames, name);
            listOfStudentsHomeTown.Insert(namePos, homeTown);
            listOfStudentsFavoriteFood.Insert(namePos, favFood);
            listOfStudentsFavoriteColor.Insert(namePos, favColor);
        }
        public static int BinaryInsert<T>(List<T> elements, T item) where T : IComparable
        {
            return BinaryInsertRescursive(elements, item, 0, elements.Count);
        }
        private static int BinaryInsertRescursive<T>(List<T> elements, T item, int startIndex, int finishIndex) where T : IComparable
        {
            if (startIndex == finishIndex)
            {
                elements.Insert(startIndex, item);
                return startIndex;
            }
            int pos = startIndex + (finishIndex - startIndex) / 2;
            if (item.CompareTo(elements[pos]) <= 0)
                finishIndex = pos;
            else
                startIndex = pos + 1;
            return BinaryInsertRescursive(elements, item, startIndex, finishIndex);
        }
