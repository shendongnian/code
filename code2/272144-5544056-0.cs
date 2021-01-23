    var Client = PopulateDTO(); //put all the values in the controls, to an object
    
    if(Action==Actions.Create){
      _repository.Create(Client);
    }
    else if(Action==Actions.Update){
      _repository.Update(Client);
    }
    else if(Action==Actions.Delete){
      _repository.Delete(Client);
    }
    
    this.Close();
