    public class VMFoo
    {
        public VMFoo()
        {
            this.MySaveVM = new UV2002_RFPBeheren_ViewModel();
        }
        public UV2002_RFPBeheren_ViewModel MySaveVM { get; set; }
    }
    public class UV2002_RFPBeheren_ViewModel
    {
        private DelegateCommand _save;
        public ICommand SaveRFPCommand
        {
            get{if(this._save==null)
            {
                this._save = new DelegateCommand(()=>MessageBox.Show("success"),()=>true);
            }
                return this._save;
            }
        }
    }
