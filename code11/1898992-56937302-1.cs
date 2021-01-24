    public class CatSettings
    {
        public readonly int AnswerToAllCats;
        public CatSettings(int answerToAllCats) => AnswerToAllCats = answerToAllCats;
    }
    public class CatManager : ICatManager
    {
        public CatManager(ICatCastle castle, CatSettings settings) ...
    }
