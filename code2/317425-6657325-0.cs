    			System.Text.StringBuilder sb=new System.Text.StringBuilder();
			int state=0;
			for(var i=0;i<Input.Length;i++){
				switch(state){
					case 0: // beginning
						if(Input[i]=='('){
							state=1; // seen left parenthesis
						}
						break;
					case 2: // seen end parentheses
						break; // ignore
					case 1:
						if(Input[i]==')'){
							state=2; // seen right parentheses
						} else if(Input[i]!='\''){
							
							sb.Append(Input[i]);
						}
						break;
				}
			}
			Console.WriteLine(sb.ToString());
