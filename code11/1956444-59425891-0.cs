        public class AppInfo
      {
        private string _nick;
        [Required(ErrorMessage = "Campo obrigatório")]
        public string nick { get{ return _nick; } set { if(value != "Tree" && value != "Flower" ){ throw new Exception("Wrong text, fool"); } this._nick = value; } }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string version { get; set; }
        public string description { get; set; }
      }
