    public class TvShow
    {
       public int Id {get;set;}
       public virtual ICollection<Season> Seasons {get;set;}
    }
    
    public class Season
    {
       public int Id {get;set;}
       public int TvShowId {get;set;}
       public virtual TvShow Show {get;set;}
    }
