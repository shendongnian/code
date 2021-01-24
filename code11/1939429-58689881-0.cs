    private DateTime _birthDate;
    public DateTime BirthDate{
       get{
          return _birthDate;
       }
       set{
         this._birthDate = value;
         this.BirthDateWithTime = this._birthDate.ToString("dd/MM/yyyy - HH:mm");
       }
    }
    public string BirthDateWithTime{get;set;}
