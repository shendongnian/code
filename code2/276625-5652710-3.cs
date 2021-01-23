    public void addDataPoint(YourDataClass entity)
    {
        if(this.InvokeRequired)
        {// this prevents the invoke loop
           this.Invoke(new Action<YourDataClass>(addDataPoint),new object[]{entity}); // invoke call for _THIS_ function to execute on the UI thread
        }
        else{
           //function logic to actually add the datapoint goes here
           chartControl.Series[0].Points.AddXY(entity.X,entity.Y); // assuming your dataclass has the members X and Y and you are using the first Series on a MSChart control
        }
    }
