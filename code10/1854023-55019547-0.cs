    var allCards = CardRepository.FindAll().ToArray(); // Ensure array.
    query = query.ToUpper();
    var nameTask = Task.StartNew(() => allCards.Where(x => x.Name.ToUpper().Contains(query)).ToArray());
    var setTask = Task.StartNew(() => allCards.Where(x => x.Set.SetName.ToUpper().Contains(query)).ToArray());
    var variantTask = Task.StartNew(() => allCards.Where(x => x.Variant.ToUpper().Contains(query)).ToArray());
    var cardNumberTask = Task.StartNew(() => allCards.Where(x => x.CardNumber.ToUpper().Contains(query)).ToArray());
    var holoTask = Task.StartNew(() => allCards.Where(x => query == "holo" && x.IsHolo).ToArray());
    Task.WaitAll(new Task[] {nameTask, setTask, variantTask, cardNumberTask, holoTask});
    var result = (nameTask.Result + setTask.Result + variantTask.Result + cardNumberTask.Result + halaTask.Result).Distinct().ToArray();
