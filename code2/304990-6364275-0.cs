    /// <summary>
    /// Simple interface for visually confirming a question to the user
    /// </summary>
    public interface IConfirmer
    {
        bool Confirm(string message, string caption);
    }
    public class WPFMessageBoxConfirmer : IConfirmer
    {
        #region Implementation of IConfirmer
        public bool Confirm(string message, string caption) {
            return MessageBox.Show(message, caption, MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        }
        #endregion
    }
    // SomeViewModel uses an IConfirmer
    public class SomeViewModel
    {
        public ShellViewModel(ISomeRepository repository, IConfirmer confirmer) 
        {
            if (confirmer == null) throw new ArgumentNullException("confirmer");
            _confirmer = confirmer;
			
			...
        }
		...
		
        private void _delete()
        {
            var someVm = _masterVm.SelectedItem;
            Check.RequireNotNull(someVm);
            if (detailVm.Model.IsPersistent()) {
                var msg = string.Format(GlobalCommandStrings.ConfirmDeletion, someVm.DisplayName);
                if(_confirmer.Confirm(msg, GlobalCommandStrings.ConfirmDeletionCaption)) {
                    _doDelete(someVm);
                }
            }
            else {
                _doDelete(someVm);
            }
		}
		...
	}
	// usage in the Production code	
	var vm = new SomeViewModel(new WPFMessageBoxConfirmer());
    // usage in a unit test
	[Test]
	public void DeleteCommand_OnExecute_IfUserConfirmsDeletion_RemovesSelectedItemFrom_Workspaces() {
		var confirmerMock = MockRepository.GenerateStub<IConfirmer>();
		confirmerMock.Stub(x => x.Confirm(Arg<string>.Is.Anything, Arg<string>.Is.Anything)).Return(true);
		var vm = new ShellViewModel(_repository, _crudConverter, _masterVm, confirmerMock, _validator);
		vm.EditCommand.Execute(null);
		Assert.That(vm.Workspaces, Has.Member(_masterVm.SelectedItem));
		Assert.That(vm.Workspaces, Is.Not.Empty);
		vm.DeleteCommand.Execute(null);
		Assert.That(vm.Workspaces, Has.No.Member(_masterVm.SelectedItem));
		Assert.That(vm.Workspaces, Is.Empty);
	}
