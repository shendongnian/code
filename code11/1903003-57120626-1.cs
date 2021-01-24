    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Test
    {
        private object classmates;
    public PersonResponse Add(PersonInsertRequest item)
    {
        var controller = new PersonController(classmates);
        return ValidateAndExecute(() => controller.ValidateInsert(item),
        () => controller.ExecuteInsert(item));
    }
    public PersonResponse Update(PersonUpdateRequest item)
    {
        var controller = new PersonController(classmates);
        return ValidateAndExecute(() => controller.ValidateUpdate(item),
        () => controller.ExecuteUpdate(item));
    }
    private PersonResponse ValidateAndExecute(Func<IEnumerable<string>> validator,
    Func<PersonResponse> execute)
    {
        var result = new PersonResponse();
        result.Messages = validator();
        if (result.Messages != null && result.Messages.Any())
        {
            result.Status = "failed";
        }
        else
        {
            result = execute();
        }
        return result;
    }
}
