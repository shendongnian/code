	using (var vm = new TestModel())
	{
		Debug.Assert(UndoList.Undo() == false);
		vm.TestProperty = true;
		Debug.Assert(UndoList.Undo() == true);
		Debug.Assert(UndoList.Undo() == false);
		Debug.Assert(vm.TestProperty == false);
		vm.DoBusinessAction();
		Debug.Assert(UndoList.Undo() == true);
		Debug.Assert(vm.HasBusinessActionBeenDone == false);
		vm.DoBusinessAction();
	}
	Debug.Assert(UndoList.Undo() == false);
