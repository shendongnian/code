    public string GenerateOrderID()
    {
        lock(this){
            return String.Format("{0:yyyyMMddHHmmss}{1}", DateTime.Now, orderCount++);
        }
    }
