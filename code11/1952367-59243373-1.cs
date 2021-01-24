    [HttpPost]
        public JsonResult PostData(YourVMClass vm)
        {
            switch (vm.SelectedQuestion)
            {
                case "CB1":
                    //Question1CB1 = true;
                case "CB2":
                    //Question1CB2 = true;
                case "CB3":
                    //Question1CB3 = true;
                default:
                    break;
            }
        }
