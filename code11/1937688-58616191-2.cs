    private async Task DoScan(ObjModel obj)
    {
        bool check = await Task.Run(() =>
        {
            MachineController.Instance.MoveToCIndex(obj.C - 1);
            return MachineController.Instance.Scan();
        }
        ...
    }
