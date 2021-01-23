    public void patientInsert()
    {
        hospitalSQLEntities db = new hospitalSQLEntities();
        int newid = 0;
        //LOOK HERE: "patientid" - removed quotes (assuming patientid is a variable)
        //LOOK HERE: Substring - removed second parameter (isn't needed, and anyway, once you get higher than 100, you'll need to change your code from 2 to 3)
        string mynumberstring = patientid.Substring(1);
        int patientid1 = Convert.ToInt32(mynumberstring);
        //LOOK HERE: removed p variable (too simple - waste of space)
        //string p = "p";
        if (db.patients.Count() == 0)
        {
            newid = 1;
        }
        else
        {
            //LOOK HERE: are you trying to get the max id from the database?  if so, then this wont work. you need something like this:
            //newid = db.patients.Max(u => patientid1) + 1;
            newid = db.patients.Max(u => Int32.Parse(u.patientid.Substring(1))) + 1;
            //LOOK HERE: newid is defined as int. It can't be changed to string.
            //newid = Convert.ToString(newid);
            //newid = newid < 2, + "0"; 
            //newid = (p + patientid1);
        }
        patient newpatient = new patient();
        //LOOK HERE: newid is a variable, not a page parameter
        //newpatient.patientid = Convert.ToString(Request.Params["newid"]);
        //LOOK HERE: Look at String.format - this is your key to the leading zeros
        newpatient.patientid = String.Format("P{0:00}", newid);
        newpatient.doctorno = Convert.ToInt16(Request.Params["doctorno"]);
        newpatient.wardno = Request.Params["wardno"];
        newpatient.patientname = Request.Params["patientname"];
        newpatient.address = Request.Params["address"];
        newpatient.gender = Request.Params["gender"];
        newpatient.bloodtype = Request.Params["bloodtype"];
        newpatient.spam = Convert.ToBoolean(Request.Params["spam"]);
        newpatient.organs = Convert.ToBoolean(Request.Params["organs"]);
        db.AddTopatients(newpatient);
        db.SaveChanges();
    }
