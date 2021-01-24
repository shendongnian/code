    string val;
                if (vm.Name != null)
                {
                    val = "VM name is \"{0}\" and";
                }
                else
                {
                    val = "VM";
                }
                Console.WriteLine(
                      val + " ID is \"{1}\". State is: \"{2}\". Location: \"{3}\" and the Instance Type is \"{4}\". Key is \"{5}\".",
                      vm.Name, vm.InstanceId,
                      vm.State, vm.Region, vm.InstanceType, vm.KeyName);
