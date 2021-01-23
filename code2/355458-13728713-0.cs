        private static void FillDependencyTreeLeaves(ServiceController controller, List<ServiceController> controllers)
        {
            bool dependencyAdded = false;
            foreach (ServiceController dependency in controller.DependentServices)
            {
                ServiceControllerStatus status = dependency.Status;
                // add only those that are actually running
                if (status != ServiceControllerStatus.Stopped && status != ServiceControllerStatus.StopPending)
                {
                    dependencyAdded = true;
                    FillDependencyTreeLeaves(dependency, controllers);
                }
            }
            // if no dependency has been added, the service is dependency tree's leaf
            if (!dependencyAdded && !controllers.Contains(controller))
            {
                controllers.Add(controller);
            }
        }
