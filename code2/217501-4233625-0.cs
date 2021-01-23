	void SetAnDealerPrice(ButtonEventArgs args, IBroker broker,
			FunctionEntry entry) {
		if (args.Button != ItemType.SendAutoButton)
			return;
		int phase = broker.TradingPhase;
		if (phase == 1 || phase == 2)
			entry.SetParameter("ANDealerPrice", -1);
	}
	void SetAnAutoUpdate(ButtonEventArgs args, IBroker broker,
			FunctionEntry entry) {
		if (args.Button != ItemType.SendAutoButton)
			return;
		switch (broker.TradingPhase) {
		case 1:
			entry.SetParameter("ANAutoUpdate", 4);
			break;
		case 2:
			entry.SetParameter("ANAutoUpdate", 2);
			break;
		}
	}
	void SetValue(IBroker broker, FunctionEntry entry) {
		if (broker.TradingPhase != 1)
			return;
		entry.SetParameter("Value", broker.IsCashBMK ? 100 : 200);
	}
