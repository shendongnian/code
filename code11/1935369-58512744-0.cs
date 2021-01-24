       bool val = true;
          if (jobTxt.Text.Trim() == string.Empty) {
              val = false;
          }
    if(val==true){
        command.ExecuteNonQuery();
    }
    else{
    MessageBox.Show("Some field is empty")
    }
