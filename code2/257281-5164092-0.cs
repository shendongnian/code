    public static SqlConnection conn
    get{
      if(this == null)
      {
          this = new SqlConnection();
      }else{
          if(!this.Open()){
              this.Connect();
          }
      }
    }
