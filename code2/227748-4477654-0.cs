    public static CastHelper<T> Cast<T>(this T obj) {
        return new CastHelper<T>(obj);
    }
    public struct CastHelper<TFrom> {
        private readonly TFrom obj;
        public CastHelper(TFrom obj) { this.obj = obj;}
        public TTo To<TTo>() {
           // your code here
        }
    }
