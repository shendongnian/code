        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controller;
            // Do stuff to resolve dependency
            if(controller is LongTaskController)
            {
                ((LongTaskController) controller).CompleteLongTask += (sender, args) => _container.Release(controller);
            }
        }
        public override void ReleaseController(IController controller)
        {
            // by releasing the container, Windsor will call my Dispose() method on my repository
            if(!(controller is LongTaskController && ((LongTaskController)controller).HasLongTask)
            {
                _container.Release(controller);
            }
            base.ReleaseController(controller);
        }
