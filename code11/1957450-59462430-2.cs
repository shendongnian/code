       public void ChangeState() {
        bool updated;
        if(onScreenDrawing.enabled){
            onScreenDrawing.enabled = false;
            updated = true
         }else{
          if(updated == false){
             onScreenDrawing.enabled = true;
          }
        }
    }
