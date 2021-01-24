            private string dia = null;
            public string Dia {
                get {
                    if(dia != null) {
                        return dia;
                    }
    
                    UnityWebRequest www = UnityWebRequest.Get ("http://localhost/Linx/Fechas.php");
                    yield return www.SendWebRequest ();
                    string fechasDatos = www.downloadHandler.text;
                    print (fechasDatos);
                    fechas = fechasDatos.Split (';');
                    dia = GetValorDatos (fechas[0], "Dia:");
                }
            }
