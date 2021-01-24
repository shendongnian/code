    Student searchStudent(String searchName)
    {
        var strLines = File.ReadLines(filePath);
        foreach (var line in strLines)
        {
            var split = line.Split(',');
            if (split[0].Equals(searchName))
            {
                Student s = new Student()
                {
                    firstname = searchName,
                    surname = split[1],
                    city = split[2],
                    state = split[3]
                };
                return s; //return the object containing the matched name
            }
        }
        return null;
    }
    
    private void Load_Script_Click(object sender, EventArgs e)
    {
        // load script is button 
    
        String con_env = textenv.Text.ToString();
        //Address Address = GetAddress("vikas");
        //textsurname.text = Address.Surname
    
        Student st = searchStudent(con_env);
        textsurname.Text = st.surname;
        txtcity.Text = st.city;
        txtstate.Text = st.state;
    }
    
    namespace DDL_SCRIPT_GENERATOR
    {
        public class Student
        {
            public string firstname { get; set; }
            public string surname { get; set; }
            public string city { get; set; }
            public string state { get; set; }
        }
    }
