    selected.AddRange(from StateMD state in states
                                  from MemorableD memorable in memorables
                                  where state.Month == memorable.Month && state.Day == memorable.Day
                                  let selectValue = new MemorableD(memorable.Year, memorable.Month, memorable.Day, memorable.Event, state.Event)
                                  select selectValue);
