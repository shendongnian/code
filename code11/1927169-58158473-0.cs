    public class CapturaModel {
        public IList<Captura> captura;
    };
        //...
        var resultJson = JsonConvert.SerializeObject(new CapturaModel { captura = models.captura; });
