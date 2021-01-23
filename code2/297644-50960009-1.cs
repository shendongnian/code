      List<ListViewItem> ITEMS = new List<ListViewItem>();
    private void loadListView(ListView lv)
    {
        int numberOfRows = 20;
        string[] student_number, first_name, last_name, middle_name, extension, course, year, section;
          //    ...... Assign values to the arrays above...
        for (int h = 0; h <= numberOfRows - 1; h++)
            {
                ListViewItem OneItem = new ListViewItem();
                OneItem.Background = course[h] == "Grade" ? Brushes.Red : Brushes.Transparent; //Decide the color of the Row
                OneItem.Content = new Student
                {
                    Student_Number = student_number[h],
                    Course = course[h],
                    Section = section[h],
                    Year = year[h],
                    FullName = first_name[h] + " " + middle_name[h] + ". " + last_name[h] + " " + extension[h]
                };
                ITEMS.Add(OneItem);
                lv.ItemsSource = ITEMS;
            }
            lv.Items.Refresh();
    }
    public class Student
    {
        public string Student_Number { get; set; }
        public string FullName { get; set; }
        public string Course { get; set; }
        public string Section { get; set; }
        public string Year { get; set; }
    }
