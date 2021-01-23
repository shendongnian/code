    public class Foo : IBiasSvdPredictor {
        public float PredictRating(IBiasSvdModel, string user, string artist) { .... }
        // this is an expicit implementation of ISvdPredictor's method. You satisfy
        // the interface, but this method is not a public part of the class. You have to
        // cast the object to ISvdPredictor in order to use this method.
        float ISvdPredictor.PredictRating(ISvdModel model, string user, string artist) {
            this.PredictRating((IBiasSvdModel)model, user, artist);
        }
    }
