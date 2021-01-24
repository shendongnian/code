    public class AsistenciaList:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int idasistencia { get; set; }
        public DateTime fecha { get; set; }
        public int idtipo_evento { get; set; }
        public string tipo_evento { get; set; }
        public int idmaestro_grupo { get; set; }
        public int idalumno_grupo { get; set; }
        public string alumno { get; set; }
      
        public string notas { get; set; }
        private bool asis;
        public bool asistencia
        {
            get
            {
                return asis;
            }
            set
            {
                if (asis != value)
                {
                    asis = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private bool falta;
        public bool falta_justificada
        {
            get
            {
                return falta;
            }
            set
            {
                if (falta != value)
                {
                    falta = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
