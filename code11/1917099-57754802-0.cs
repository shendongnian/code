       ..
       if (PatientImage.Image != null)
       {
          Image dummy = PatientImage.Image; 
          PatientImage.Image = null; 
          dummy.Dispose(); 
       }
       ..
