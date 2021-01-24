    public void DoSomethingSagaCoordinator {
        public void Handle(CommandContext cmdCtx) {
            var saga = new DoSomethingSaga(cmdCtx);
            sagaRepository.Save(saga);
            saga.Process();
            sagaRepository.Update(saga);
        }
    }
