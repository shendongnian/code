    private static void BurstSingle(Transaction transaction, Database database, 
     BlockReference blockReference)
    {
      BlockTableRecord theModelSpaceBlock = 
     (BlockTableRecord)transaction.GetObject(blockReference.BlockId, OpenMode.ForWrite);
    
      foreach (ObjectId attributeReferenceId in blockReference.AttributeCollection)
      {
     AttributeReference attributeReference = 
      (AttributeReference)transaction.GetObject(attributeReferenceId, OpenMode.ForWrite);
    
     Entity textVersionOfAttributeReference;
    
     if (attributeReference.IsMTextAttribute)
     {
       MText mText = (MText)attributeReference.MTextAttribute.Clone();
       textVersionOfAttributeReference = mText;
     }
     else
     {
       DBText dbText = new DBText();
       dbText.SetDatabaseDefaults(database);
       dbText.Thickness = attributeReference.Thickness;
    
       if (attributeReference.LayerId == database.LayerZero)
      dbText.LayerId = blockReference.LayerId;
       else
      dbText.LayerId = attributeReference.LayerId;
    
       if (attributeReference.ColorIndex == EntityColorIndex_ByBlock)
      dbText.ColorIndex = blockReference.ColorIndex;
       else
      dbText.ColorIndex = attributeReference.ColorIndex;
    
       if (attributeReference.Linetype.ToUpper() == "BYBLOCK")
      dbText.LinetypeId = blockReference.LinetypeId;
       else
      dbText.LinetypeId = attributeReference.LinetypeId;
    
       dbText.Height = attributeReference.Height;
       dbText.TextString = attributeReference.TextString;
       dbText.Rotation = attributeReference.Rotation;
       dbText.Oblique = attributeReference.Oblique;
       dbText.SetTextStyle(attributeReference.GetTextStyle());
       dbText.IsMirroredInX = attributeReference.IsMirroredInX;
       dbText.IsMirroredInY = attributeReference.IsMirroredInY;
       dbText.HorizontalMode = attributeReference.HorizontalMode;
       dbText.VerticalMode = attributeReference.VerticalMode;
    
       if (attributeReference.AlignmentPoint.Y != 0.0)
      dbText.AlignmentPoint = attributeReference.AlignmentPoint;
    
       dbText.Position = attributeReference.Position;
       dbText.Normal = attributeReference.Normal;
       dbText.WidthFactor = attributeReference.WidthFactor;
    
       textVersionOfAttributeReference = dbText;
    
       theModelSpaceBlock.AppendEntity(textVersionOfAttributeReference);
       transaction.AddNewlyCreatedDBObject(textVersionOfAttributeReference, true);
     }
      }
    
      DBObjectCollection explodedParts = new DBObjectCollection();
      blockReference.Explode(explodedParts);
    
      foreach (Entity explodedPart in explodedParts)
      {
     if (!(explodedPart is AttributeDefinition))
     {
       if (explodedPart.ColorIndex == EntityColorIndex_ByBlock)
      explodedPart.ColorIndex = blockReference.ColorIndex;
    
       if (explodedPart.LayerId == database.LayerZero)
      explodedPart.LayerId = blockReference.LayerId;
    
       if (explodedPart.Linetype.ToUpper() == "BYBLOCK")
      explodedPart.LinetypeId = blockReference.LinetypeId;
    
       theModelSpaceBlock.AppendEntity(explodedPart);
       transaction.AddNewlyCreatedDBObject(explodedPart, true);
     }
    
     explodedPart.Dispose();
      }
    
      explodedParts.Clear();
    
      blockReference.Erase();
    }
