    //create Task<bool>
    private async Task<bool> ObterListaDeContas()
        {
            try
            {
                //ProgressRing activation
                CarregamentoDeContas.IsActive = true;
                //DoSomethingBig() or await Task.Delay(3000)-only for learning
                return true;
            }
            catch
            {
                //catch your exceptions
                return false;
            }
        }
        private void DeactiveProgressBar(bool isDone)
        {
            //ProgressRing deactivation when the task is over
            CarregamentoDeContas.IsActive = false;
        }
