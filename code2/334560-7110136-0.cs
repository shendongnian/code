    public interface ISvdModel
    {
        float[,] UserFeatures { get; set; }
        float[,] ArtistFeatures { get; set; }
    }
    public interface IBiasSvdModel : ISvdModel
    {
        float GlobalAverage { get; set; }
        float[] UserBias { get; set; }
        float[] ArtistBias { get; set; }
    }
    public interface ISvdPredictor<in TSvdModel>
        where TSvdModel : ISvdModel // Require that TSvdModel implements ISvdModel
    {
        List<string> Users { get; set; }
        List<string> Artists { get; set; }
        float PredictRating(TSvdModel model, string user, string artist);
        float PredictRating(TSvdModel model, int userIndex, int artistIndex);
    }
    // I would actually avoid declaring this interface. Rather, see comment on the class.
    public interface IBiasSvdPredictor : ISvdPredictor<IBiasSvdModel> { }
    class BiasSvdPredictor : IBiasSvdPredictor // Preferred : ISvdPredictor<IBiasSvdModel>
    {
        // ...
        public float PredictRating(IBiasSvdModel model, string user, string artist) { }
        public float PredictRating(IBiasSvdModel model, int userIndex, int artistIndex) { }
    }
