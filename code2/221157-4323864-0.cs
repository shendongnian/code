    public void DealWithDataItem(DataItem item)
    {
        item.Step1(); // does not change the state of `this` 
                      // and only changes variables that are private to `item`
        item.Step2(); // and a lot of StepN(item)
    }
