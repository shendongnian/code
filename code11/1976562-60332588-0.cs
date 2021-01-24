    private void btSearch_Click(object sender, EventArgs e)
    {
        lstOutput.Items.Clear();
        do
        {
            searchName();
            if (index != -1)
            {
                people.RemoveAt(index);
            }
        }
        while (!isnull);
    }
    List<Person> people = new List<Person> {
        new Person { No = 1, Surname = "Smith"} ,
        new Person { No = 2, Surname = "Smit"},
        new Person { No = 3, Surname = "Bob"},
        new Person { No = 4, Surname = "KKK"},
        new Person { No = 5, Surname = "Obt"},
        new Person { No = 6, Surname = "Peter"}};
    private void Form1_Load(object sender, EventArgs e)
    {
        lstOutput.View = View.Details;
        people.Sort((x, y) => { return x.Surname.CompareTo(y.Surname); });
    }
    bool isnull = false;
    int index;
    private void searchName()
    {
        index = BinarySearch(people, 0, people.Count, txtSurname.Text);
        if (index != -1)
        {
            ListViewItem phone = new ListViewItem();
            phone.Text = (Convert.ToString(people[index].No));
            phone.SubItems.Add(Convert.ToString(people[index].Surname));
            lstOutput.Items.Add(phone);
        }
        else
        {
            isnull = true;
        }
    }
    List<int> list = new List<int>();
    private int BinarySearch(List<Person> p, int low, int high, string key)
    {
        int mid = (low + high) / 2;
        if (low > high)
            return -1;
        else
        {
            try
            {
                string str = p[mid].Surname.Substring(0, key.Length);
                if (string.Compare(str, key) == 0)
                    return mid;
                else if (string.Compare(str, key) > 0)
                    return BinarySearch(p, low, mid - 1, key);
                else
                    return BinarySearch(p, mid + 1, high, key);
            }
            catch
            {
                return -1;
            }
        }
    }
    class Person
    {
        public int No { get; set; }
        public string Surname { get; set; }
    }
