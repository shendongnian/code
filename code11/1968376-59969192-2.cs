      ...
      Dictionary<Player, List<Attribute>> dictionary = new Dictionary<Player, List<Attribute>>();
      dictionary.Add(
        player("Lebron James"), 
        attribute("mid height", "mid weidght", "high vertical")
      );
    }
    private Player player(string name){
      return new Player(name);
    }
    private List<Attribute> attribute(params string[] strAttributes){
      List<Attribute> resultList = new List<Attribute>();
      foreach(string strAttr in strAttributes){
        resultList.Add(new Attribute(strAttr));
      }
      return resultList;
    }
