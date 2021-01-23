    public interface IEnemy{
       int GetScore();
    }
    
    public class Martian : IEnemy{
       int GetScore(){ return 10; }
    }
    
    public class Vesuvian : IEnemy{
       int GetScore(){ return 20; }
    }
    ...
