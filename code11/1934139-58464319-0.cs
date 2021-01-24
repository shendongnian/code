    public float RotationCar = 1;            
        private bool increase = true;
    
    
    if (increase)
                {
                    if (RotationCar < 1)
                        RotationCar += Time.deltaTime * 1;
                    else
                        increase = false;
                }
                else
                {
                    if (RotationCar > -1)
                        RotationCar -= Time.deltaTime * 1;
                    else
                        increase = true;
                }
    
                this.transform.Rotate(0, 0, RotationCar);
