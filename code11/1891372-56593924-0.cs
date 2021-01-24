    public string UserName { get; set; }
    public string Answer1 { get; set; }
    public string Answer2 { get; set; }
    
     public void Save()
     {
        var db2 = new DBEntities();
        db2.Questionnaire.Add(new Questionnaire() {
          Answer1 = Answer1,
          Answer2 = Answer2,
          UserName = UserName,
          //ETC...
            });
            db2.SaveChanges();
        }
