    SignatureUtil signatureUtil = new SignatureUtil(pdfDocument);
    foreach (string name in signatureUtil.GetSignatureNames())
    {
        Console.WriteLine("\nInspecting signature '{0}':", name);
        PdfDictionary dict = signatureUtil.GetSignatureDictionary(name);
        PdfArray referenceArray = dict.GetAsArray(PdfName.Reference);
        if (referenceArray == null | referenceArray.Size() == 0)
        {
            Console.WriteLine("The signature does not apply a transform.");
            continue;
        }
        foreach (PdfObject referenceArrayObject in referenceArray)
        {
            PdfObject referenceObject = referenceArrayObject;
            if (referenceObject.IsIndirectReference())
                referenceObject = ((PdfIndirectReference)referenceObject).GetRefersTo(true);
            if (referenceObject.IsIndirectReference())
            {
                Console.WriteLine("A transform is too deeply nested.");
                continue;
            }
            if (!referenceObject.IsDictionary())
            {
                Console.WriteLine("A transform is not a dictionary.");
                continue;
            }
            PdfDictionary reference = (PdfDictionary)referenceObject;
            PdfName method = reference.GetAsName(PdfName.TransformMethod);
            if (method == null)
            {
                Console.WriteLine("The signature does not provide the name of its transform method. (Invalid!)");
                continue;
            }
            if (new PdfName("UR").Equals(method))
            {
                Console.WriteLine("The signature is a usage rights signature.");
                continue;
            }
            if (PdfName.DocMDP.Equals(method))
            {
                Console.WriteLine("The signature has a DocMDP transform method, it is a certification signature.");
            }
            else if (PdfName.FieldMDP.Equals(method))
            {
                Console.WriteLine("The signature has a FieldMDP transform method.");
            }
            else
            {
                Console.WriteLine("The signature has the unknown '{0}' transform method. (Invalid!)", method);
                continue;
            }
            PdfDictionary transformParams = reference.GetAsDictionary(PdfName.TransformParams);
            if (transformParams == null)
            {
                Console.WriteLine("The transform has no parameters. (Invalid!)");
                continue;
            }
            PdfName action = transformParams.GetAsName(PdfName.Action);
            if (action != null)
            {
                if (PdfName.All.Equals(action))
                {
                    Console.WriteLine("The transform locks all form fields.");
                }
                else
                {
                    PdfArray fields = transformParams.GetAsArray(PdfName.Fields);
                    if (PdfName.Include.Equals(action))
                    {
                        if (fields == null)
                            Console.WriteLine("The transform locks all listed form fields but does not provide the list. (Invalid!)");
                        else
                            Console.WriteLine("The transform locks all the listed form fields: {0}", fields);
                    }
                    else if (PdfName.Exclude.Equals(action))
                    {
                        if (fields == null)
                            Console.WriteLine("The transform locks all except listed form fields but does not provide the list. (Invalid!)");
                        else
                            Console.WriteLine("The transform locks all except the listed form fields: {0}", fields);
                    }
                    else
                    {
                        Console.WriteLine("The transform uses the unknown action '{0}' for field locking. (Invalid!)", action);
                    }
                }
            }
            PdfNumber p = transformParams.GetAsNumber(PdfName.P);
            if (p != null)
            {
                switch (p.IntValue())
                {
                    case 1:
                        Console.WriteLine("The transform locks the document entirely.");
                        break;
                    case 2:
                        Console.WriteLine("The transform restricts document manipulation to at most filling in forms, instantiating page templates, and signing.");
                        break;
                    case 3:
                        Console.WriteLine("The transform restricts document manipulation to at most filling in forms, instantiating page templates, and signing, as well as annotation creation, deletion, and modification.");
                        break;
                    default:
                        Console.WriteLine("The transform access permissions value is unknown: {0}. (Invalid!)", p.IntValue());
                        break;
                }
                Console.WriteLine("In a PAdES or PDF-2 context, addition of validation related information and proofs of existence is additionally allowed.");
            }
        }
    }
