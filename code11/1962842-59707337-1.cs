    switch (entity)
    {
        case TPersonA a when toEdit is TPersonA castedEntity:
            castedEntity.Specialization = a.Specialization;
            break;
        case TPersonB b when toEdit is TPersonB castedEntity:
            castedEntity.AIndex = b.AIndex;
            break;
    }
