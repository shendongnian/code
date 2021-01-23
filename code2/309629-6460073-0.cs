    abstract class Action {
        protected abstract Repository GetRepository();
        protected void Update(){
           this.GetRepository().Update(this);
        }
    }
