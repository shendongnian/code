    protected virtual void DataBind(bool raiseOnDataBinding) {
        bool inDataBind = false;
        if (foundDataItem && (Page != null)) { 
            Page.PushDataBindingContext(dataItem);
            inDataBind = true;
        }
        try{
        //...
        } finally {
            if (inDataBind) { 
                Page.PopDataBindingContext(); 
            }
        }
    }
