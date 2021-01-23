			// Recupere le contenu du controle editBox dans la variable Cible
			public void  RecupDonnee(IRibbonControl control, String Text)
			{
				switch (control.Id)
				{
					case "FileNumber":						
						FileNumberText = Text.Trim() ;	
						break;
					case "editBox02":
						Screen2 = Text.Trim() ;	
						break;
				}		
			}
