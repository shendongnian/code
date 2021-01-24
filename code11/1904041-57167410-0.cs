       public void DealWithBorder(List<Control> lsControls) {
			foreach(var element in lsControls){
				dynamic dynamicElement = element;
				try{
					BorderStyle style = dynamicElement.BorderStyle;
					// Handle if property does exist in the control
				}
				catch{
					// Handle if property doesnt exist in the control
				}
			}
		}
