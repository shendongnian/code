    while ((line = file.ReadLine()) != null)
    {
                string[] split = line.Split(',');
                MyClass myclass = new MyClass();
                myclass.date = DateTime.Parse(split[2]);
                MyClass.originalLine = line; // <---------
                myClassList.Add(myclass);
    }
